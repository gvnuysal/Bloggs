import React from 'react';
import { FormComponentProps } from 'antd/lib/form';
import TagStore from '../../../stores/tagStore';
import { Form, Input, Modal, Checkbox } from 'antd';
import { L } from '../../../lib/abpUtility';
import FormItem from 'antd/lib/form/FormItem';
import tagRules from './createOrUpdateTag.validation';

export interface ICreateOrUpdateTagProps extends FormComponentProps {
  tagStore: TagStore;
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onOk: () => void;
  isDeleted: boolean;
}
class CreateOrUpdateTag extends React.Component<ICreateOrUpdateTagProps> {
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

    let modalType = this.props.modalType;
    let isDeleted = this.props.isDeleted;

    const { getFieldDecorator } = this.props.form;
    return (
      <Modal
        visible={this.props.visible}
        cancelText={L('Cancel')}
        okText={L('Save')}
        onCancel={this.props.onCancel}
        title={L('Tags')}
        onOk={this.props.onOk}
      >
        <FormItem label={L('TagName')} {...formItemLayout}>
          {getFieldDecorator('name', { rules: tagRules.name })(<Input />)}
        </FormItem>
        {modalType == 'edit' && isDeleted ? (
          <FormItem label={L('IsDeleted')} {...formItemLayout}>
            {getFieldDecorator('isDeleted', { valuePropName: 'checked' })(<Checkbox />)}
          </FormItem>
        ) : (
          ''
        )}
      </Modal>
    );
  }
}

export default Form.create<ICreateOrUpdateTagProps>()(CreateOrUpdateTag);
