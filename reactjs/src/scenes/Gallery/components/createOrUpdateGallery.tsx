import * as React from 'react';

import { Form, Input, Modal, Upload, Select, Row } from 'antd';

import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateGallery.validation';

export interface ICreateOrUpdateGallerysProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}
export interface ICreateOrUpdateGallerysState {
  fileList: any;
}

class CreateOrUpdateGallerys extends React.Component<
  ICreateOrUpdateGallerysProps,
  ICreateOrUpdateGallerysState
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
      image1: info.fileList[0]?.url,
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
        title={L('Gallery')}
        width={750}
        style={{ top: 50 }}
      >
        <Form ref={formRef} onFieldsChange={this.onFieldsChange}>
          <Row gutter={16}>
            
              <Form.Item label={L('Title')} name={'imageTitle'} rules={rules.imageTitle} {...formItemLayout}>
                <Input />
              </Form.Item>
              
              <Form.Item
                label={L('Gallery Category')}
                name={'categoryName'}
                rules={rules.type}
                {...formItemLayout}
              >
                <Select placeholder="Please Select Type" defaultValue="Gym">
                  <Select.Option value="gym">Gym</Select.Option>
                  <Select.Option value="firstAid">First Aid</Select.Option>
                  <Select.Option value="boutique">Boutique</Select.Option>
                </Select>
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
            
             </Row>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateGallerys;
