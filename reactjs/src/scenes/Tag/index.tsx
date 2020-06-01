import * as React from 'react';

import TagStore from '../../stores/tagStore';
import { FormComponentProps } from 'antd/lib/form';
import AppComponentBase from '../../components/AppComponentBase';
import { observer, inject } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import { L } from '../../lib/abpUtility';
import { Dropdown, Menu, Button, Card, Col, Row, Table, Input, Modal, Checkbox } from 'antd';
import { EntityDto } from '../../services/dto/entityDto';
import CreateOrUpdateTag from './components/createOrUpdateTag';
export interface ITagProps extends FormComponentProps {
  tagStore: TagStore;
}
export interface ITagState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  tagId: number;
  filter: string;
  isDeleted: boolean;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.TagStore)
@observer
class Tag extends AppComponentBase<ITagProps, ITagState> {
  formRef: any;
  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    tagId: 0,
    filter: '',
    isDeleted: false,
  };
  async componentDidMount() {
    await this.getAll();
  }
  async getAll() {
    await this.props.tagStore.getAll({
      maxResultCount: this.state.maxResultCount,
      keyword: this.state.filter,
      skipCount: this.state.skipCount,
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
      await this.props.tagStore.createTag();
    } else {
      await this.props.tagStore.getTagForEdit(entityDto);
    }
    this.setState({ tagId: entityDto.id });
    this.Modal();
    this.formRef.props.form.setFieldsValue({
      ...this.props.tagStore.tagEdit.tag,
    });
  }
  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
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
        if (this.state.tagId === 0) {
          await this.props.tagStore.create(values);
        } else {
          await this.props.tagStore.update({ id: this.state.tagId, ...values });
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
        self.props.tagStore.delete(input);
      },
      onCancel() {},
    });
  }
  options = {};
  render() {
    let { isDeleted } = this.state;

    const { tags } = this.props.tagStore;
    const columns = [
      { title: L('TagName'), dataIndex: 'name', key: 'name', width: 150 },
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
                  {/*<Menu.Item onClick={() => this.delete({ id: item.id })}>{L('Delete')}</Menu.Item>*/}
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
            <h2>{L('Tags')}</h2>
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
              pagination={{ pageSize: this.state.maxResultCount, total: tags === undefined ? 0 : tags.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={tags === undefined ? true : false}
              dataSource={tags === undefined ? [] : tags.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateTag
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          onCancel={() => {
            this.setState({ modalVisible: false });
          }}
          modalType={this.state.tagId === 0 ? 'create' : 'edit'}
          onOk={this.handleCreate}
          tagStore={this.props.tagStore}
          isDeleted={this.state.isDeleted}
        />
      </Card>
    );
  }
}

export default Tag;
