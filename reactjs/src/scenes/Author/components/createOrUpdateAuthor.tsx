import React from 'react';
import { FormComponentProps } from 'antd/lib/form';
import AuthorStore from '../../../stores/authorStore';
import { Form, /*Input,*/ Modal, Checkbox } from 'antd';
import { L } from '../../../lib/abpUtility';
import FormItem from 'antd/lib/form/FormItem';
//import authorRules from './createOrUpdateAuthor.validation';

export interface ICreateOrUpdateAuthorProps extends FormComponentProps {
  authorStore: AuthorStore;
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onOk: () => void;
  isDeleted: boolean;
}
class CreateOrUpdateAuthor extends React.Component<ICreateOrUpdateAuthorProps> {
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
        title={L('Authors')}
        onOk={this.props.onOk}
      >
        {/*<FormItem label={L('AuthorName')} {...formItemLayout}>
          {getFieldDecorator('name', { rules: authorRules.name })(<Input />)}
        </FormItem>*/}
        <FormItem label={L('IsActive')} {...formItemLayout}>
          {getFieldDecorator('isActive', { valuePropName: 'checked' })(<Checkbox />)}
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

export default Form.create<ICreateOrUpdateAuthorProps>()(CreateOrUpdateAuthor);
