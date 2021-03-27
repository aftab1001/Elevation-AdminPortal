import * as React from 'react';

import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table } from 'antd';
import { FormInstance } from 'antd/lib/form';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import CreateOrUpdateRoom from './components/createOrUpdateRooms';
import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import RoomStore from '../../stores/roomStore';
import { PlusOutlined, SettingOutlined } from '@ant-design/icons';

export interface IRoomProps {
  roomStore: RoomStore;
}

export interface IRoomState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  roomId: number;
  filter: string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.RoomStore)
@observer
class Room extends AppComponentBase<IRoomProps, IRoomState> {
  formRef = React.createRef<FormInstance>();

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    roomId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.roomStore.getAll({
      maxResultCount: this.state.maxResultCount,
      skipCount: this.state.skipCount,
      keyword: this.state.filter,
    });
  }

  handleTableChange = (pagination: any) => {
    this.setState(
      { skipCount: (pagination.current - 1) * this.state.maxResultCount! },
      async () => await this.getAll()
    );
  };

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };

  async createOrUpdateModalOpen(entityDto: EntityDto) {
    if (entityDto.id === 0) {
      this.props.roomStore.createRoom();
    } else {
      await this.props.roomStore.get(entityDto);
    }

    this.setState({ roomId: entityDto.id });
    this.Modal();

    setTimeout(() => {
      if (entityDto.id !== 0) {
        this.formRef.current?.setFieldsValue({
          ...this.props.roomStore.roomModel,
        });
      } else {
        this.formRef.current?.resetFields();
      }
    }, 100);
  }

  delete(input: EntityDto) {
    const self = this;
    confirm({
      title: 'Do you Want to delete rooms?',
      onOk() {
        self.props.roomStore.delete(input);
      },
      onCancel() {},
    });
  }

  handleCreate = async () => {
    this.formRef.current?.validateFields().then(async (values: any) => {
      if (this.state.roomId === 0) {
        await this.props.roomStore.create(values);
      } else {
        await this.props.roomStore.update({ id: this.state.roomId, ...values });
      }

      await this.getAll();
      this.setState({ modalVisible: false });
      this.formRef.current?.resetFields();
    });
  };

  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
  };

  public render() {    
    const { rooms } = this.props.roomStore;   
    const columns = [
      {
        title: L('Name'),
        dataIndex: 'name',
        key: 'name',
        width: 150,
        render: (text: string) => <div>{text}</div>,
      },      
      {
        title: L('Price'),
        dataIndex: 'price',
        key: 'price',
        width: 50,
        render: (text: number) => <div>{text}</div>,
      },      
      {
        title: L('Bed'),
        dataIndex: 'bed',
        key: 'bed',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Bath'),
        dataIndex: 'bath',
        key: 'bath',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Length'),
        dataIndex: 'length',
        key: 'length',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Actions'),
        width: 100,
        render: (text: string, item: any) => (
          <div>
            <Dropdown
              trigger={['click']}
              overlay={
                <Menu>
                  <Menu.Item onClick={() => this.createOrUpdateModalOpen({ id: item.id })}>
                    {L('Edit')}
                  </Menu.Item>
                  <Menu.Item onClick={() => this.delete({ id: item.id })}>{L('Delete')}</Menu.Item>
                </Menu>
              }
              placement="bottomLeft"
            >
              <Button type="primary" icon={<SettingOutlined />}>
                {L('Actions')}
              </Button>
            </Dropdown>
          </div>
        ),
      },
    ];

    return (
      <Card>
        <Row>
          <Col
            xs={{ span: 4, offset: 0 }}
            sm={{ span: 4, offset: 0 }}
            md={{ span: 4, offset: 0 }}
            lg={{ span: 2, offset: 0 }}
            xl={{ span: 2, offset: 0 }}
            xxl={{ span: 2, offset: 0 }}
          >
            <h2>{L('Rooms')}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
            <Button
              type="primary"
              shape="circle"
              icon={<PlusOutlined />}
              onClick={() => this.createOrUpdateModalOpen({ id: 0 })}
            />
          </Col>
        </Row>
        <Row>
          <Col sm={{ span: 10, offset: 0 }}>
            <Search placeholder={this.L('Filter')} onSearch={this.handleSearch} />
          </Col>
        </Row>
        <Row style={{ marginTop: 20 }}>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey="id"
              bordered={true}
              pagination={{
                pageSize: this.state.maxResultCount,
                total: rooms === undefined ? 0 : rooms.totalCount,
                defaultCurrent: 1,
              }}
              columns={columns}
              loading={rooms === undefined ? true : false}
              dataSource={rooms === undefined ? [] : rooms.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateRoom
          formRef={this.formRef}
          visible={this.state.modalVisible}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.roomId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
      </Card>
    );
  }
}

export default Room;
