import CategoryStore from '../../stores/categoryStore';
import { FormComponentProps } from 'antd/lib/form';

import AppComponentBase from '../../components/AppComponentBase';

import { observer, inject } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import { L } from '../../lib/abpUtility';
import { Dropdown, Menu, Button, Card, Col, Row, Table } from 'antd';
import Search from 'antd/lib/input/Search';

export interface ICategoryProps extends FormComponentProps {
  categoryStore: CategoryStore;
}
export interface ICategoryState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  categoryId: number;
  filter: string;
}
// const confirm = Modal.confirm;
// const Search = Input.Search;

@inject(Stores.CategorySore)
@observer
class Category extends AppComponentBase<ICategoryProps, ICategoryState> {
  formRef: any;
  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    categoryId: 0,
    filter: '',
  };
  async componentDidMount() {
    await this.getAll();
  }
  async getAll() {
    await this.props.categoryStore.getAll({ maxResultCount: this.state.maxResultCount, keyword: this.state.filter, skipCount: this.state.skipCount });
  }
  handleTableChange = (pagination: any) => {
    this.setState({ skipCount: (pagination.current - 1) * this.state.maxResultCount! }, async () => await this.getAll());
  };

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };
  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
  };
  public render() {
    const { categories } = this.props.categoryStore;
    const columns = [
      { title: 'Kategori Adı', dataIndex: 'name', key: 'name', width: 150, render: (text: string) => <div>{text}</div> },
      {
        title: L('Actions'),
        width: 150,
        render: (text: string, item: any) => (
          <div>
            <Dropdown
              trigger={['click']}
              overlay={
                <Menu>
                  <Menu.Item onClick={() => {}}>{L('Edit')}</Menu.Item>
                  <Menu.Item onClick={() => {}}>{L('Delete')}</Menu.Item>
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
            <h2>{L('Categories')}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
            <Button type="primary" shape="circle" icon="plus" onClick={() => {}} />
          </Col>
        </Row>
        <Row>
          <Col sm={{ span: 10, offset: 0 }}>
            <Search placeholder={this.L('Filter')} onSearch={this.handleSearch} />
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
              pagination={{ pageSize: this.state.maxResultCount, total: categories === undefined ? 0 : categories.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={categories === undefined ? true : false}
              dataSource={categories === undefined ? [] : categories.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
      </Card>
    );
  }
}

export default Category;
