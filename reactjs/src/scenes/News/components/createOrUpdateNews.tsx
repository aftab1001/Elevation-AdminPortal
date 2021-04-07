import * as React from 'react';
import { Form, Input, Modal, Upload, Col, Row } from 'antd';
import { FormInstance } from 'antd/lib/form';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateNews.validation';

export interface ICreateOrUpdateNewsProps {
  visible: boolean;
  modalType: string;
  onCreate: () => Promise<void>;
  onCancel: () => void;
  formRef: React.RefObject<FormInstance>;
}
export interface ICreateOrUpdateNewsState {
  fileList: any;
  fileList2: any;
  fileList3: any;
}

class CreateOrUpdateNews extends React.Component<
  ICreateOrUpdateNewsProps,
  ICreateOrUpdateNewsState
> {
  constructor(props: any) {
    super(props);
    this.state = {
      fileList: [],
      fileList2: [],
      fileList3: [],
    };
  }
  onFieldsChange = (changedFields: any, allFields: any) => {
    const image1 = this.props.formRef.current?.getFieldValue('image1');
    const image2 = this.props.formRef.current?.getFieldValue('image2');
    const image3 = this.props.formRef.current?.getFieldValue('image3');

    this.setState({ fileList: [{ uid: -1, url: image1 }] });
    this.setState({ fileList2: [{ uid: -1, url: image2 }] });
    this.setState({ fileList3: [{ uid: -1, url: image3 }] });
  };

  onChange = (fieldName: string, info: any) => {
    info.fileList.forEach(function (file: any, index: number) {
      let reader = new FileReader();
      reader.onload = (e: any) => {
        file.url = e.target.result;
      };
      reader.readAsDataURL(info.file.originFileObj);
    });

    if (fieldName === 'image1') {
      this.props.formRef.current?.setFieldsValue({
        image1: info.fileList[0]?.url,
      });
      this.setState({ fileList: info.fileList });
    } else if (fieldName === 'image2') {
      this.props.formRef.current?.setFieldsValue({
        image2: info.fileList[0]?.url,
      });
      this.setState({ fileList2: info.fileList });
    } else if (fieldName === 'image3') {
      this.props.formRef.current?.setFieldsValue({
        image3: info.fileList[0]?.url,
      });
      this.setState({ fileList3: info.fileList });
    }
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
    const formItemLayoutImage = {
      labelCol: {
        xs: { span: 6 },
        sm: { span: 6 },
        md: { span: 6 },
        lg: { span: 6 },
        xl: { span: 6 },
        xxl: { span: 6 },
      },
      wrapperCol: {
        xs: { span: 9 },
        sm: { span: 9 },
        md: { span: 9 },
        lg: { span: 9 },
        xl: { span: 9 },
        xxl: { span: 9 },
      },
    };

    const { visible, onCancel, onCreate, formRef } = this.props;

    return (
      <Modal
        visible={visible}
        onCancel={onCancel}
        onOk={onCreate}
        title={L('News')}
        width={1050}
        style={{ top: 50 }}
      >
        <Form ref={formRef} onFieldsChange={this.onFieldsChange}>
          <Form.Item label={L('Title')} name={'title'} rules={rules.title} {...formItemLayout}>
            <Input />
          </Form.Item>
          <Form.Item
            label={L('Description 1')}
            name={'description1'}
            rules={rules.description1}
            {...formItemLayout}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item
            label={L('Description 2')}
            name={'description2'}
            rules={rules.description2}
            {...formItemLayout}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item
            label={L('Description 3')}
            name={'description3'}
            rules={rules.description3}
            {...formItemLayout}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item
            label={L('Description 4')}
            name={'description4'}
            rules={rules.description4}
            {...formItemLayout}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item
            label={L('Description 5')}
            name={'description5'}
            rules={rules.description5}
            {...formItemLayout}
          >
            <Input.TextArea />
          </Form.Item>
          <Form.Item label={L('Image1')} name={'image1'} {...formItemLayout} hidden={true}>
            <Input />
          </Form.Item>
          <Form.Item label={L('Image2')} name={'image2'} {...formItemLayout} hidden={true}>
            <Input />
          </Form.Item>
          <Form.Item label={L('Image3')} name={'image3'} {...formItemLayout} hidden={true}>
            <Input />
          </Form.Item>
          <Row>
            <Col span={8}>
              <Form.Item label={L('Image1')} {...formItemLayoutImage}>
                <Upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  listType="picture-card"
                  fileList={this.state.fileList}
                  onChange={this.onChange.bind(this, 'image1')}
                  onPreview={this.onPreview}
                >
                  {this.state.fileList.length < 1 && '+ Upload'}
                </Upload>
              </Form.Item>
            </Col>
            <Col span={8}>
              <Form.Item label={L('Image2')} {...formItemLayoutImage}>
                <Upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  listType="picture-card"
                  fileList={this.state.fileList2}
                  onChange={this.onChange.bind(this, 'image2')}
                  onPreview={this.onPreview}
                >
                  {this.state.fileList2.length < 1 && '+ Upload'}
                </Upload>
              </Form.Item>
            </Col>
            <Col span={8}>
              <Form.Item label={L('Image3')} {...formItemLayoutImage}>
                <Upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  listType="picture-card"
                  fileList={this.state.fileList3}
                  onChange={this.onChange.bind(this, 'image3')}
                  onPreview={this.onPreview}
                >
                  {this.state.fileList3.length < 1 && '+ Upload'}
                </Upload>
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    );
  }
}

export default CreateOrUpdateNews;
