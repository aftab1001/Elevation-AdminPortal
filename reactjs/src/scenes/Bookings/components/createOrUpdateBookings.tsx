import * as React from 'react';

import { Form, Input, Modal, Select, Row, Col, InputNumber, DatePicker } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateBookings.validation';
import BookingStore from './../../../stores/bookingStore';
import BookingItemStore from './../../../stores/bookingItemStore';
import BookingService from './../../../services/booking/bookingService';
import FormItem from 'antd/lib/form/FormItem';
import moment from 'moment';

export interface ICreateOrUpdateBookingsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
  bookingStore: BookingStore;
  bookingItemStore: BookingItemStore;
}

class CreateOrUpdateBookings extends React.Component<ICreateOrUpdateBookingsProps> {
  constructor(props: any) {
    super(props);
  }
  state = {
    fromDate: moment(),
    toDate: moment(),
    items: [],
  };
  getItemTypes = async (itemType: number) => {
    const result = await BookingService.getItemByType({
      bookingType: itemType,
    });
    this.setState({ items: result });
  };

  async componentDidMount() {
    this.getItemTypes(0);
  }
  onItemChange = (value: number) => {
    this.getItemTypes(value);
  };

  onRangeChange = (momentValues: any, dateRange: any) => {
    console.log(dateRange);
  };
  onFieldsChange = (changedFields: any, allFields: any) => {
    const fDate = this.props.formRef.current?.getFieldValue('fromDate');
    const tDate = this.props.formRef.current?.getFieldValue('toDate');
    if (fDate && tDate) {
      this.setState({ fromDate: fDate, toDate: tDate });
    } else {
      this.setState({ fromDate: moment(), toDate: moment() });
    }
  };
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
    const { fromDate, toDate, items } = this.state;
    const dateFormat = 'YYYY-MM-DD';
    const { RangePicker } = DatePicker;
    let roomItems =
      items.length === 0
        ? [{ id: 0, name: 'please create rooms first', price: '123' }]
        : [...items];
    return (
      <Modal
        visible={visible}
        onCancel={onCancel}
        onOk={onCreate}
        title={L('Bookings')}
        width={1050}
        style={{ top: 50 }}
      >
        <Form ref={formRef} onFieldsChange={this.onFieldsChange}>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                label={L('From Date')}
                rules={rules.fromDate}
                name={'dateRange'}
                {...formItemLayout}
              >
                <RangePicker
                  format={dateFormat}
                  onChange={this.onRangeChange}
                  inputReadOnly={true}
                  name={'range'}
                  defaultValue={[moment(new Date(fromDate)), moment(new Date(toDate))]}
                />
              </Form.Item>
              <FormItem hidden={true} name={'fromDate'}>
                <input />
              </FormItem>
              <FormItem hidden={true} name={'toDate'}>
                <input />
              </FormItem>

              <Form.Item
                label={L('First Name')}
                name={'firstName'}
                rules={rules.firstName}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Last Name')}
                name={'lastName'}
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
                name={'contactNumber'}
                rules={rules.contactNumber}
                {...formItemLayout}
              >
                <InputNumber />
              </Form.Item>

              <Form.Item
                label={L('Special Request')}
                name={'specialRequest'}
                rules={rules.specialRequest}
                {...formItemLayout}
              >
                <Input.TextArea />
              </Form.Item>
              <Form.Item
                label={L('Booking Type')}
                name={'bookingType'}
                rules={rules.bookingType}
                {...formItemLayout}
              >
                <Select placeholder="Please Select">
                  <Select.Option value={0}>Customer</Select.Option>
                  <Select.Option value={1}>Service</Select.Option>
                </Select>
              </Form.Item>

              <Form.Item
                label={L('Item Type')}
                name={'roomType'}
                rules={rules.roomType}
                {...formItemLayout}
              >
                <Select placeholder="Please Select" onChange={this.onItemChange}>
                  <Select.Option value={0}>Room</Select.Option>
                  <Select.Option value={1}>Apartment</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item
                label={L('Paid Price')}
                name={'price'}
                rules={rules.pricePaid}
                {...formItemLayout}
              >
                <InputNumber />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item label={L('Please Select Items')} name={'itemId'} {...formItemLayout}>
                <Select placeholder="Please Select">
                  {roomItems.map((item) => {
                    return (
                      <Select.Option value={item.id}>
                        {item.name}--{item.price}
                      </Select.Option>
                    );
                  })}
                </Select>
              </Form.Item>

              <Form.Item
                label={L('Booking Status')}
                name={'bookingStatus'}
                rules={rules.bookingStatus}
                {...formItemLayout}
              >
                <Select placeholder="Please Select">
                  <Select.Option value={0}>Active</Select.Option>
                  <Select.Option value={1}>Revoked</Select.Option>
                </Select>
              </Form.Item>

              <Form.Item
                label={L('Admin Comments')}
                name={'adminComments'}
                rules={rules.adminComments}
                {...formItemLayout}
              >
                <Input.TextArea />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateBookings;
