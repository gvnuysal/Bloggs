import React from 'react';
import { FormComponentProps } from 'antd/lib/form';
import CategoryStore from '../../../stores/categoryStore';
import { Form, Input, Modal, Checkbox } from 'antd';
import { L } from '../../../lib/abpUtility';
import FormItem from 'antd/lib/form/FormItem';
import categoryRules from './createOrUpdateCategory.validation';

export interface ICreateOrUpdateCategoryProps extends FormComponentProps {
  categoryStore: CategoryStore;
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onOk: () => void;
}
class CreateOrUpdateCategory extends React.Component<ICreateOrUpdateCategoryProps> {
  state = {
    confirmDirty: false,
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

    const { getFieldDecorator } = this.props.form;
    return (
      <Modal
        visible={this.props.visible}
        cancelText={L('Cancel')}
        okText={L('Save')}
        onCancel={this.props.onCancel}
        title={L('Categories')}
        onOk={this.props.onOk}
      >
        <FormItem label={L('CategoryName')} {...formItemLayout}>
          {getFieldDecorator('name', { rules: categoryRules.name })(<Input />)}
        </FormItem>
        <FormItem label={L('CategoryDescription')} {...formItemLayout}>
          {getFieldDecorator('description')(<Input />)}
        </FormItem>
        <FormItem label={L('IsActive')} {...formItemLayout}>
          {getFieldDecorator('isActive', { valuePropName: 'checked' })(<Checkbox />)}
        </FormItem>
      </Modal>
    );
  }
}

export default Form.create<ICreateOrUpdateCategoryProps>()(CreateOrUpdateCategory);
