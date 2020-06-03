import * as React from 'react';

import ArticleStore from '../../stores/articleStore';
import { FormComponentProps } from 'antd/lib/form';
import AppComponentBase from '../../components/AppComponentBase';
import { observer, inject } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import { L } from '../../lib/abpUtility';
import { Dropdown, Menu, Button, Card, Col, Row, Table, Input, Modal, Checkbox } from 'antd';
import { EntityDto } from '../../services/dto/entityDto';
import CreateOrUpdateArticle from './components/createOrUpdateArticle';
export interface IArticleProps extends FormComponentProps {
  articleStore: ArticleStore;
}
export interface IArticleState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  articleId: number;
  filter: string;
  isActive: boolean;
  isDeleted: boolean;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.ArticleStore)
@observer
class Article extends AppComponentBase<IArticleProps, IArticleState> {
  formRef: any;
  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    articleId: 0,
    filter: '',
    isDeleted: false,
    isActive: true,
  };
  async componentDidMount() {
    await this.getAll();
  }
  async getAll() {
    await this.props.articleStore.getAll({
      maxResultCount: this.state.maxResultCount,
      keyword: this.state.filter,
      skipCount: this.state.skipCount,
      isActive: this.state.isActive,
      isDeleted: this.state.isDeleted,
    });
  }
  handleTableChange = (pagination: any) => {
    this.setState({ skipCount: (pagination.current - 1) * this.state.maxResultCount! }, async () => await this.getAll());
  };

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };
  async createOrUpdateModalOpen(entityDto: EntityDto) {
    if (entityDto.id === 0) {
      await this.props.articleStore.createArticle();
    } else {
      await this.props.articleStore.getArticleForEdit(entityDto);
    }
    this.setState({ articleId: entityDto.id });
    this.Modal();
    this.formRef.props.form.setFieldsValue({
      ...this.props.articleStore.articleEdit.article,
    });
  }
  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
  };
  handleSearchForIsActive = (value: any) => {
    this.setState({ isActive: value.currentTarget.checked }, async () => await this.getAll());
  };
  handleSearchForIsDeleted = (value: any) => {
    this.setState({ isDeleted: value.currentTarget.checked }, async () => await this.getAll());
  };
  saveFormRef = (formRef: any) => {
    this.formRef = formRef;
  };
  handleCreate = () => {
    const form = this.formRef.props.form;
    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.articleId === 0) {
          await this.props.articleStore.create(values);
        } else {
          await this.props.articleStore.update({ id: this.state.articleId, ...values });
        }
      }

      await this.getAll();
      this.setState({ modalVisible: false });
      form.resetFields();
    });
  };

  delete(input: EntityDto) {
    const self = this;
    confirm({
      title: L('DoYouWantDelete'),
      onOk() {
        self.props.articleStore.delete(input);
      },
      onCancel() {},
    });
  }
  options = {};
  render() {
    const { articles } = this.props.articleStore;
    const { isDeleted } = this.state;
    const columns = [
      { title: L('ArticleTitle'), dataIndex: 'title', key: 'title', width: 150 },
      { title: L('ArticleContent'), dataIndex: 'contents', key: 'contents', width: 150 },
      { title: L('Category'), dataIndex: 'category.name', key: 'categoryName', width: 150 },
      { title: L('Author'), dataIndex: 'author.user.fullName', key: 'authorName', width: 150 },
      {
        title: L('Actions'),
        width: 150,
        render: (text: string, item: any) => (
          <div>
            <Dropdown
              trigger={['click']}
              overlay={
                <Menu>
                  <Menu.Item onClick={() => this.createOrUpdateModalOpen({ id: item.id })}>{L('Edit')}</Menu.Item>
                  {!isDeleted && <Menu.Item onClick={() => this.delete({ id: item.id })}>{L('Delete')}</Menu.Item>}
                </Menu>
              }
              placement="bottomLeft"
            >
              <Button type="primary" icon="setting">
                {L('Actions')}
              </Button>
            </Dropdown>
          </div>
        ),
      },
    ];
    return (
      <Card>
        <Row>
          <Col
            xs={{ span: 4, offset: 0 }}
            sm={{ span: 4, offset: 0 }}
            md={{ span: 4, offset: 0 }}
            lg={{ span: 2, offset: 0 }}
            xl={{ span: 2, offset: 0 }}
            xxl={{ span: 2, offset: 0 }}
          >
            <h2>{L('Articles')}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
            <Button type="primary" shape="circle" icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: 0 })} />
          </Col>
        </Row>
        <Row>
          <Col sm={{ span: 6, offset: 0 }}>
            <Search placeholder={L('Filter')} onSearch={this.handleSearch} />
          </Col>
          <Col sm={{ span: 5, offset: 1 }}>
            <Checkbox defaultChecked={true} onClick={this.handleSearchForIsActive}>
              {L('IsActive')}
            </Checkbox>
            <Checkbox onClick={this.handleSearchForIsDeleted}>{L('IsDeleted')}</Checkbox>
          </Col>
        </Row>
        <Row style={{ marginTop: 20 }}>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey="id"
              size={'default'}
              bordered={true}
              pagination={{ pageSize: this.state.maxResultCount, total: articles === undefined ? 0 : articles.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={articles === undefined ? true : false}
              dataSource={articles === undefined ? [] : articles.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateArticle
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          onCancel={() => {
            this.setState({ modalVisible: false });
          }}
          modalType={this.state.articleId === 0 ? 'create' : 'edit'}
          onOk={this.handleCreate}
          articleStore={this.props.articleStore}
          isDeleted={this.state.isDeleted}
        />
      </Card>
    );
  }
}

export default Article;
