import * as React from 'react';

import AuthorStore from '../../stores/authorStore';
import { FormComponentProps } from 'antd/lib/form';
import AppComponentBase from '../../components/AppComponentBase';
import { observer, inject } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import { L } from '../../lib/abpUtility';
import { Dropdown, Menu, Button, Card, Col, Row, Table, Input, Modal, Checkbox, Tag } from 'antd';
import { EntityDto } from '../../services/dto/entityDto';
import CreateOrUpdateAuthor from './components/createOrUpdateAuthor';
export interface IAuthorProps extends FormComponentProps {
  authorStore: AuthorStore;
}
export interface IAuthorState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  authorId: number;
  filter: string;
  isActive: boolean;
  isDeleted: boolean;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.AuthorStore)
@observer
class Author extends AppComponentBase<IAuthorProps, IAuthorState> {
  formRef: any;
  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    authorId: 0,
    filter: '',
    isDeleted: false,
    isActive: true,
  };
  async componentDidMount() {
    await this.getAll();
  }
  async getAll() {
    await this.props.authorStore.getAll({
      maxResultCount: this.state.maxResultCount,
      FullName: this.state.filter,
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
      await this.props.authorStore.createAuthor();
    } else {
      await this.props.authorStore.getAuthorForEdit(entityDto);
    }
    this.setState({ authorId: entityDto.id });
    this.Modal();
    this.formRef.props.form.setFieldsValue({
      ...this.props.authorStore.authorEdit.author,
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
        if (this.state.authorId === 0) {
          await this.props.authorStore.create(values);
        } else {
          await this.props.authorStore.update({ id: this.state.authorId, ...values });
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
        self.props.authorStore.delete(input);
      },
      onCancel() {},
    });
  }
  options = {};
  render() {
    const { authors } = this.props.authorStore;
    const { isDeleted } = this.state;
    const columns = [
      { title: L('AuthorName'), dataIndex: 'user.fullName', key: 'name', width: 150 },
      {
        title: L('IsActive'),
        dataIndex: 'isActive',
        key: 'isActive',
        width: 150,
        render: (text: boolean) => (text === true ? <Tag color="#2db7f5">{L('Yes')}</Tag> : <Tag color="red">{L('No')}</Tag>),
      },
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
            <h2>{L('Authors')}</h2>
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
              pagination={{ pageSize: this.state.maxResultCount, total: authors === undefined ? 0 : authors.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={authors === undefined ? true : false}
              dataSource={authors === undefined ? [] : authors.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateAuthor
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          onCancel={() => {
            this.setState({ modalVisible: false });
          }}
          modalType={this.state.authorId === 0 ? 'create' : 'edit'}
          onOk={this.handleCreate}
          authorStore={this.props.authorStore}
          isDeleted={this.state.isDeleted}
        />
      </Card>
    );
  }
}

export default Author;
