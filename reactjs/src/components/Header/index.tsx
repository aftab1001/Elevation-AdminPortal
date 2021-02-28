import './index.less';

import * as React from 'react';

import {  Col,  Row } from 'antd';
import { MenuUnfoldOutlined, MenuFoldOutlined } from '@ant-design/icons';
/*
import { L } from '../../lib/abpUtility';
import { Link } from 'react-router-dom';

import profilePicture from '../../images/user.png';
*/
export interface IHeaderProps {
  collapsed?: any;
  toggle?: any;
}
/*
const userDropdownMenu = (
  <Menu>
    <Menu.Item key="2">
      <Link to="/logout">
        <LogoutOutlined />
        <span> {L('Logout')}</span>
      </Link>
    </Menu.Item>
  </Menu>
);
*/
export class Header extends React.Component<IHeaderProps> {
  render() {
    return (
      <Row className={'header-container'}>
        <Col style={{ textAlign: 'left' }} span={12}>
          {this.props.collapsed ? (
            <MenuUnfoldOutlined className="trigger" onClick={this.props.toggle} />
          ) : (
            <MenuFoldOutlined className="trigger" onClick={this.props.toggle} />
          )}
        </Col>
        {/*<Col style={{ padding: '0px 15px 0px 15px', textAlign: 'right' }} span={12}>
          <Dropdown overlay={userDropdownMenu} trigger={['click']}>
            <Avatar
              style={{ height: 45, width: 45 }}
              shape="circle"
              alt={'profile'}
              src={profilePicture}
            />
          </Dropdown>
          </Col>*/}
      </Row>
    );
  }
}

export default Header;
