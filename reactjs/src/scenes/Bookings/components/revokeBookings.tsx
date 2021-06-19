import * as React from 'react';

import { Form, Input, Modal, Row } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './revokeBookings.validation';

export interface IRevokeBookingsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}
export interface IRevokeBookingsState {
  
}

class RevokeBookings extends React.Component<
  IRevokeBookingsProps,
  IRevokeBookingsState
> {
  constructor(props: any) {
    super(props);
    
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
        <Form ref={formRef} >
          <Row gutter={16}>
          <Form.Item
                label={L('adminComments')}
                name={'adminComments'}
                rules={rules.adminComments}
                {...formItemLayout}
              >
                <Input.TextArea />
              </Form.Item>
            
          </Row>
        </Form>
      </Modal>
    );
  }
}

export default RevokeBookings;
