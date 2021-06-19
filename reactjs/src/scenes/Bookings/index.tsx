import * as React from 'react';

import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table, Tag } from 'antd';
import { FormInstance } from 'antd/lib/form';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import CreateOrUpdateBooking from './components/createOrUpdateBookings';
import RevokeBooking from './components/revokeBookings';
import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import BookingStore from '../../stores/bookingStore';
import { PlusOutlined, SettingOutlined } from '@ant-design/icons';

export interface IBookingProps {
  bookingStore: BookingStore;
}

export interface IBookingState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  bookingId: number;
  filter: string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.BookingStore)
@observer
class Booking extends AppComponentBase<IBookingProps, IBookingState> {
  formRef = React.createRef<FormInstance>();

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    bookingId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.bookingStore.getAll({
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
      this.props.bookingStore.createBooking();
    } else {
      await this.props.bookingStore.get(entityDto);
    }

    this.setState({ bookingId: entityDto.id });
    this.Modal();

    setTimeout(() => {
      if (entityDto.id !== 0) {
        this.formRef.current?.setFieldsValue({
          ...this.props.bookingStore.bookingModel,
        });
      } else {
        this.formRef.current?.resetFields();
      }
      this.formRef.current?.submit();
    }, 100);
  }
  async revokedModalOpen(entityDto: EntityDto) {
    if (entityDto.id === 0) {
      this.props.bookingStore.createBooking();
    } else {
      await this.props.bookingStore.get(entityDto);
    }

    this.setState({ bookingId: entityDto.id });
    this.Modal();

    setTimeout(() => {
      if (entityDto.id !== 0) {
        this.formRef.current?.setFieldsValue({
          ...this.props.bookingStore.bookingModel,
        });
      } else {
        this.formRef.current?.resetFields();
      }
      this.formRef.current?.submit();
    }, 100);
  }

  delete(input: EntityDto) {
    const self = this;
    confirm({
      title: 'Do you Want to delete bookings?',
      onOk() {
        self.props.bookingStore.delete(input);
      },
      onCancel() {},
    });
  }

  handleCreate = async () => {
    this.formRef.current?.validateFields().then(async (values: any) => {
      if (this.state.bookingId === 0) {
        await this.props.bookingStore.create(values);
      } else {
        await this.props.bookingStore.update({ id: this.state.bookingId, ...values });
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
    const { bookings } = this.props.bookingStore;
    const columns = [
      {
        title: L('ItemName'),
        dataIndex: 'roomName',
        key: 'roomName',
        width: 100,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('ItemType'),
        dataIndex: 'itemType',
        key: 'itemType',
        width: 50,
        render: (text: number) => <div>{text === 0 ? 'Room' : 'Apartment'}</div>,
      },
      {
        title: L('FromDate'),
        dataIndex: 'fromDate',
        key: 'fromDate',
        width: 50,
        render: (text: string) => <div>{new Date(text).toLocaleDateString()}</div>,
      },
      {
        title: L('ToDate'),
        dataIndex: 'toDate',
        key: 'toDate',
        width: 50,
        render: (text: string) => <div>{new Date(text).toLocaleDateString()}</div>,
      },
      {
        title: L('GuestName'),
        dataIndex: 'guestName',
        key: 'guestName',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('GuestContact'),
        dataIndex: 'contactNumber',
        key: 'contactNumber',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('GuestEmail'),
        dataIndex: 'email',
        key: 'email',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('SpecialRequest'),
        dataIndex: 'specialRequest',
        key: 'specialRequest',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('PricePaid'),
        dataIndex: 'price',
        key: 'price',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('BookingType'),
        dataIndex: 'bookingType',
        key: 'bookingType',
        width: 50,
        render: (text: number) => <div>{text === 0 ? 'Customer' : 'Service'}</div>,
      },
      {
        title: L('BookingStatus'),
        dataIndex: 'bookingStatus',
        key: 'bookingStatus',
        width: 50,
        render: (status: number) => {
          if (status === 0) {
            return <Tag color="green">Active</Tag>;
          } else {
            return <Tag color="red">Revoked</Tag>;
          }
        },
      },
      {
        title: L('AdminComments'),
        dataIndex: 'adminComments',
        key: 'adminComments',
        width: 100,
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
                    {L('Edit Bookings')}
                  </Menu.Item>
                  <Menu.Item onClick={() => this.revokedModalOpen({ id: item.id })}>{L('Revoke')}</Menu.Item>
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
            <h2>{L('Bookings')}</h2>
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
                total: bookings === undefined ? 0 : bookings.totalCount,
                defaultCurrent: 1,
              }}
              columns={columns}
              loading={bookings === undefined ? true : false}
              dataSource={bookings === undefined ? [] : bookings.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateBooking
          formRef={this.formRef}
          visible={this.state.modalVisible}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.bookingId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
        <RevokeBooking
          formRef={this.formRef}
          visible={this.state.modalVisible}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.bookingId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
      </Card>
    );
  }
}

export default Booking;
