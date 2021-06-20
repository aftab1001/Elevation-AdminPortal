import * as React from 'react';

import { Form, Input, Modal, Select, Row, Col, InputNumber } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateBookings.validation';
import BookingStore from '../../stores/bookingStore';
export interface ICreateOrUpdateBookingsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
  bookingStore:BookingStore
}
export interface ICreateOrUpdateBookingsState {
  
}

class CreateOrUpdateBookings extends React.Component<
  ICreateOrUpdateBookingsProps,
  ICreateOrUpdateBookingsState
> {
  constructor(props: any) {
    super(props);
    console.log(props);
  }

  componentDidMount = () => {
    console.log("store",this.props.bookingStore);
    await this.getItems();
  };

  async getItems() {
    console.log("testing");
    await this.props.bookingStore.getItemByType({
      maxResultCount: this.state.maxResultCount,
      skipCount: this.state.skipCount,
      keyword: this.state.filter,
    });
  }

  render() {
    const formItemLayout = {
      labelCol: {
        xs: { span: 6 },
        sm: { span: 6 },
        md: { span: 6 },
        lg: { span: 6 },
        xl: { span: 6 },
        xxl: { span: 6 },
      },
      wrapperCol: {
        xs: { span: 18 },
        sm: { span: 18 },
        md: { span: 18 },
        lg: { span: 18 },
        xl: { span: 18 },
        xxl: { span: 18 },
      },
    };

    const { visible, onCancel, onCreate, formRef } = this.props;

    return (
      <Modal
        visible={visible}
        onCancel={onCancel}
        onOk={onCreate}
        title={L('Bookings')}
        width={1050}
        style={{ top: 50 }}
      >
        <Form ref={formRef}>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                label={L('FromDate')}
                name="fromDate"
                rules={rules.fromDate}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item label={L('ToDate')} name="toDate" rules={rules.toDate} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item
                label={L('FirstName')}
                name="firstName"
                rules={rules.firstName}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('lastName')}
                name="lastName"
                rules={rules.lastName}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item label={L('email')} name="email" rules={rules.email} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Contact')}
                name="contactNumber"
                rules={rules.contactNumber}
                {...formItemLayout}
              >
                <InputNumber />
              </Form.Item>

              <Form.Item
                label={L('specialRequest')}
                name="specialRequest"
                rules={rules.specialRequest}
                {...formItemLayout}
              >
                <Input.TextArea />
              </Form.Item>
              <Form.Item
                label={L('Booking Type')}
                name="bookingType"
                rules={rules.bookingType}
                {...formItemLayout}
              >
                <Select placeholder="Please Select" defaultValue="0">
                  <Select.Option value="0">Customer</Select.Option>
                  <Select.Option value="1">Service</Select.Option>
                </Select>
              </Form.Item>

              <Form.Item
                label={L('Item Type')}
                name="roomType"
                rules={rules.roomType}
                {...formItemLayout}
              >
                <Select placeholder="Please Select" defaultValue="0">
                  <Select.Option value="0">Room</Select.Option>
                  <Select.Option value="1">Apartment</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item
                label={L('PaidPrice')}
                name="price"
                rules={rules.pricePaid}
                {...formItemLayout}
              >
                <InputNumber />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item label={L('Please Select Room')} name="item" {...formItemLayout}>
                <Select placeholder="Please Select">
                  <Select.Option value="">a</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item
                label={L('booking Status')}
                name="bookingStatus"
                rules={rules.bookingStatus}
                {...formItemLayout}
              >
                <Select placeholder="Please Select" defaultValue="0">
                  <Select.Option value="0">Active</Select.Option>
                  <Select.Option value="1">Revoked</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item
                label={L('booking Type')}
                name="bookingType"
                rules={rules.bookingType}
                {...formItemLayout}
              >
                <Select placeholder="Please Select" defaultValue="0">
                  <Select.Option value="0">Customer</Select.Option>
                  <Select.Option value="1">Service</Select.Option>
                </Select>
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateBookings;
