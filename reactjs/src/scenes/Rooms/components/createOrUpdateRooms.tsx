import * as React from 'react';

import { Form, Input, Modal } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateRooms.validation';

export interface ICreateOrUpdateRoomsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}

class CreateOrUpdateRooms extends React.Component<ICreateOrUpdateRoomsProps> {
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
      <Modal visible={visible} onCancel={onCancel} onOk={onCreate} title={L('Rooms')} width={550}>
        <Form ref={formRef}>
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
          <Form.Item label={L('length')} name={'length'} rules={rules.length} {...formItemLayout}>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateRooms;
