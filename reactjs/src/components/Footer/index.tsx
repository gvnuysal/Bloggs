import * as React from 'react';
import { Col } from 'antd';
import './index.less';

const Footer = () => {
  return (
      <Col className={"footer"}>
      Asp.Net Boilerplate - React © 2020 ** BLOGGS ** <a href="https://github.com/gvnuysal/Bloggs.git">Github Page</a>
      </Col>
     /*<Col className={"footer"}>
      Asp.Net Boilerplate - React © 2018 <a href="https://github.com/ryoldash/module-zero-core-template">Github Page</a>
      </Col>*/
  );
};
export default Footer;
