import * as React from 'react';

import { Form, Input, Modal, Upload, Checkbox} from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateResturants.validation';

export interface ICreateOrUpdateResturantsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}
export interface ICreateOrUpdateResturantsState {
  fileList: any;
}

class CreateOrUpdateResturants extends React.Component<
  ICreateOrUpdateResturantsProps,
  ICreateOrUpdateResturantsState
> {
  constructor(props: any) {
    super(props);
    this.state = {
      fileList: [],
    };
  }
  onFieldsChange = (changedFields: any, allFields: any) => {
    const image = this.props.formRef.current?.getFieldValue('image');
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
      reader.readAsDataURL(info.file.originFileObj);
    });
    this.props.formRef.current?.setFieldsValue({
      image: info.fileList?.[0]?.url,
    });
    this.setState({ fileList: info.fileList });
  };

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
        title={L('Resturants')}
        width={700}
        style={{ top: 50 }}
      >
        <Form ref={formRef} onFieldsChange={this.onFieldsChange}>
          
            <Form.Item label={L('Name')} name={'name'} rules={rules.name} {...formItemLayout}>
              <Input />
            </Form.Item>
            <Form.Item label={L('Price')} name={'price'} rules={rules.price} {...formItemLayout}>
              <Input />
            </Form.Item>
            <Form.Item
              label={L('isPopular')}
              name={'isPopular'}
              rules={rules.IsPopular}
              {...formItemLayout}
            >
              <Checkbox  />
            </Form.Item>
            <Form.Item
              label={L('isPoster')}
              name={'isPoster'}
              rules={rules.isPoster}
              {...formItemLayout}
            >
              <Checkbox />
            </Form.Item>

            <Form.Item
              label={L('Description')}
              name={'description'}
              rules={rules.description}
              {...formItemLayout}
            >
              <Input.TextArea />
            </Form.Item>

            <Form.Item label={L('Image')} {...formItemLayout}>
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

            <Form.Item
              label={L('Image')}
              name={'image'}
              rules={rules.image}
              {...formItemLayout}
              hidden={true}
            >
              <Input />
            </Form.Item>
          
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateResturants;
