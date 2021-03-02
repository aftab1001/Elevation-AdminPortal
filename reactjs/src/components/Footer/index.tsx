import * as React from 'react';
import { Layout } from 'antd';
import './index.less';
const Footer = () => {
  
  return (
    <Layout.Footer className={'footer'} style={{ textAlign: 'center' }}>
       <a href="http://localhost:9000" target="_blank">Elevations Hotel</a> © 2021 
    </Layout.Footer>
  );
};
export default Footer;
