import * as React from 'react';

import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table, Tag } from 'antd';
import { FormInstance } from 'antd/lib/form';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import CreateOrUpdateBooking from './components/createOrUpdateBookings';

import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import BookingStore from './../../stores/bookingStore';
import BookingItemStore from './../../stores/bookingItemStore';
import { PlusOutlined, SettingOutlined } from '@ant-design/icons';
import './booking.css';

export interface IBookingProps {
  bookingStore: BookingStore;
  bookingItemStore: BookingItemStore;
}

export interface IBookingState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  bookingId: number;
  filter: string;
  fDate:string;
  tDate:string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.BookingStore, Stores.BookingItemStore)
@observer
class Booking extends AppComponentBase<IBookingProps, IBookingState> {
  formRef = React.createRef<FormInstance>();

  state = {
    modalVisible: false,
    fDate:'',
    tDate: '',
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

    this.setState({ bookingId: entityDto.id,fDate:this.props.bookingStore.bookingModel.fromDate,
    tDate:this.props.bookingStore.bookingModel.toDate });
    
   

    setTimeout(() => {
      this.Modal();
      if (entityDto.id !== 0) {
        this.formRef.current?.setFieldsValue({
          ...this.props.bookingStore.bookingModel,
        });
        
      } else {
        this.formRef.current?.resetFields();
      }
      //this.formRef.current?.submit();
    }, 200);
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
      const updatedValues = { ...values };
      const [startDate, endDate] = values.dateRange;
      updatedValues.fromDate = startDate.format('YYYY-MM-DD');
      updatedValues.toDate = endDate.format('YYYY-MM-DD');
      if (this.state.bookingId === 0) {
        await this.props.bookingStore.create(updatedValues);
      } else {
        await this.props.bookingStore.update({ id: this.state.bookingId, ...updatedValues });
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
        title: L('Item Name'),
        dataIndex: 'roomName',
        key: 'roomName',
        width: 100,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Item Type'),
        dataIndex: 'itemType',
        key: 'itemType',
        width: 50,
        render: (text: number) => <div>{text === 0 ? 'Room' : 'Apartment'}</div>,
      },
      {
        title: L('From Date'),
        dataIndex: 'fromDate',
        key: 'fromDate',
        width: 50,
        render: (text: string) => <div>{new Date(text).toLocaleDateString('en-US')}</div>,
      },
      {
        title: L('To Date'),
        dataIndex: 'toDate',
        key: 'toDate',
        width: 50,
        render: (text: string) => <div>{new Date(text).toLocaleDateString('en-US')}</div>,
      },
      {
        title: L('Guest Name'),
        dataIndex: 'guestName',
        key: 'guestName',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Guest Contact'),
        dataIndex: 'contactNumber',
        key: 'contactNumber',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Guest Email'),
        dataIndex: 'email',
        key: 'email',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Special Request'),
        dataIndex: 'specialRequest',
        key: 'specialRequest',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Price Paid'),
        dataIndex: 'price',
        key: 'price',
        width: 50,
        render: (text: string) => <div>{text}</div>,
      },
      {
        title: L('Booking Type'),
        dataIndex: 'bookingType',
        key: 'bookingType',
        width: 50,
        render: (text: number) => <div>{text === 0 ? 'Customer' : 'Service'}</div>,
      },
      {
        title: L('Booking Status'),
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
        title: L('Admin Comments'),
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
          fromDate = {this.state.fDate}
          toDate = {this.state.tDate}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.bookingId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
          bookingStore={this.props.bookingStore}
          bookingItemStore={this.props.bookingItemStore}
        />
      </Card>
    );
  }
}

export default Booking;
