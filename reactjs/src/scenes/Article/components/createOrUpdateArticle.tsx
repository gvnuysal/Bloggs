import React from 'react';
import { FormComponentProps } from 'antd/lib/form';
import ArticleStore from '../../../stores/articleStore';
import { Form, Input, Modal, Checkbox } from 'antd';
import { L } from '../../../lib/abpUtility';
import FormItem from 'antd/lib/form/FormItem';
import articleRules from './createOrUpdateArticle.validation';

export interface ICreateOrUpdateArticleProps extends FormComponentProps {
  articleStore: ArticleStore;
  visible: boolean;
  onCancel: () => void;
  modalType: string;
  onOk: () => void;
  isDeleted: boolean;
}
class CreateOrUpdateArticle extends React.Component<ICreateOrUpdateArticleProps> {
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
        title={L('Categories')}
        onOk={this.props.onOk}
      >
        <FormItem label={L('ArticleTitle')} {...formItemLayout}>
          {getFieldDecorator('title', { rules: articleRules.title })(<Input />)}
        </FormItem>
        <FormItem label={L('ArticleContent')} {...formItemLayout}>
          {getFieldDecorator('contents', { rules: articleRules.contents })(<Input />)}
        </FormItem>
        <FormItem label={L('Category')} {...formItemLayout}>
          {getFieldDecorator('categoryId', { rules: articleRules.categoryId })(<Input />)}
        </FormItem>
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

export default Form.create<ICreateOrUpdateArticleProps>()(CreateOrUpdateArticle);
