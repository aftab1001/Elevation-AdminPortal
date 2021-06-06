import * as React from 'react';

import { Form, Input, Modal, Upload, Select, Row, Col } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateBookings.validation';

export interface ICreateOrUpdateBookingsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}
export interface ICreateOrUpdateBookingsState {
  fileList: any
}

class CreateOrUpdateBookings extends React.Component<
  ICreateOrUpdateBookingsProps,
  ICreateOrUpdateBookingsState
> {
  constructor(props: any) {
    super(props);
    this.state = {
      fileList: [],
    };
  }
  onFieldsChange = (changedFields: any, allFields: any) => {
    const image = this.props.formRef.current?.getFieldValue('image1');
    if (image && image !== '') {
      this.setState({ fileList: [{ uid: -1, url: image }] });
    } else {
      this.setState({ fileList: [] });
    }
  };

  onChange = (info: any) => {
    info.fileList.forEach(function (file: any, index: number) {
      let reader = new FileReader();
      reader.onload = (e: any) => {
        file.url = e.target.result;
      };
      reader.readAsDataURL(info.file.originFileObj)
    })
    this.props.formRef.current?.setFieldsValue({
      'image1': info.fileList?.[0]?.url
    });
    this.setState({ fileList: info.fileList });
  }

  onPreview = async (file: any) => {
    let src = file.url;
    if (!src) {
      src = await new Promise((resolve) => {
        const reader = new FileReader();
        reader.readAsDataURL(file.originFileObj);
        reader.onload = () => resolve(reader.result);
      });
    }
    const image = new Image();
    image.src = src;
    const imgWindow: any = window.open(src);
    imgWindow.document.write(image.outerHTML);
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
              <Form.Item label={L('Name')} name={'name'} rules={rules.name} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item label={L('Price')} name={'price'} rules={rules.price} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item label={L('Bed')} name={'bed'} rules={rules.bed} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item label={L('Bath')} name={'bath'} rules={rules.bath} {...formItemLayout}>
                <Input />
              </Form.Item>
              <Form.Item
                label={L('length')}
                name={'length'}
                rules={rules.length}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Room Category')}
                name={'categoryName'}
                rules={rules.categoryName}
                {...formItemLayout}
              >
                <Select placeholder="Please Select Category" defaultValue="Guest House">
                  <Select.Option value="Guest House">Guest Home</Select.Option>
                  <Select.Option value="Meeting Room">Meeting Room</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item
                label={L('Description')}
                name={'description'}
                rules={rules.description}
                {...formItemLayout}
              >
                <Input.TextArea />
              </Form.Item>

              <Form.Item label={L('MainImage')} {...formItemLayout}>
                <Upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  listType="picture-card"
                  fileList={this.state.fileList}
                  onChange={this.onChange}
                  onPreview={this.onPreview}
                >
                  {this.state.fileList.length < 1 && '+ Upload'}
                </Upload>
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                label={L('Location')}
                name={'location'}
                rules={rules.location}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Features')}
                name={'features'}
                rules={rules.features}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Facilities')}
                name={'facilities'}
                rules={rules.facilities}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('NightlyPlan')}
                name={'nightlyPlan'}
                rules={rules.nightlyPlan}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('WeekendPlan')}
                name={'weekendPlan'}
                rules={rules.weekendPlan}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('WeeklyPlan')}
                name={'weeklyPlan'}
                rules={rules.weeklyPlan}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('MonthlyPlan')}
                name={'monthlyPlan'}
                rules={rules.monthlyPlan}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('CleaningFee')}
                name={'cleaningFee'}
                rules={rules.cleaningFee}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('CityFee')}
                name={'cityFee'}
                rules={rules.cityFee}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('MaxNumberOfDays')}
                name={'maxNumberOfDays'}
                rules={rules.maxNumberOfDays}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('MinNumberOfDays')}
                name={'minNumberOfDays'}
                rules={rules.minNumberOfDays}
                {...formItemLayout}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Image')}
                name={'image1'}
                rules={rules.image}
                {...formItemLayout}
                hidden={true}
              >
                <Input />
              </Form.Item>

              <Form.Item
                label={L('Image')}
                name={'image2'}
                rules={rules.image}
                {...formItemLayout}
                hidden={true}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Image')}
                name={'image3'}
                rules={rules.image}
                {...formItemLayout}
                hidden={true}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Image')}
                name={'image4'}
                rules={rules.image}
                {...formItemLayout}
                hidden={true}
              >
                <Input />
              </Form.Item>
              <Form.Item
                label={L('Image')}
                name={'image5'}
                rules={rules.image}
                {...formItemLayout}
                hidden={true}
              >
                <Input />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateBookings;
