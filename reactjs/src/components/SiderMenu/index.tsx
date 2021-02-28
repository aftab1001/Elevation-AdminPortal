import './index.less';

import * as React from 'react';

import { Avatar, Col, Layout, Menu } from 'antd';
import { L, isGranted } from '../../lib/abpUtility';

import AbpLogo from '../../images/logo.svg';
import { appRouters } from '../../components/Router/router.config';
import utils from '../../utils/utils';

const { Sider } = Layout;

export interface ISiderMenuProps {
  path: any;
  collapsed: boolean;
  onCollapse: any;
  history: any;
}

const SiderMenu = (props: ISiderMenuProps) => {
  const { collapsed, history, onCollapse } = props;
  const currentRoute = utils.getRoute(history.location.pathname);
  return (
    <Sider trigger={null} className={'sidebar'} width={256} collapsible collapsed={collapsed} onCollapse={onCollapse}>
      {collapsed ? (
        <Col style={{ textAlign: 'center', marginTop: 15, marginBottom: 10 }}>
          <Avatar shape="square" style={{ height: 50, width: 55 }} src={AbpLogo} />
        </Col>
      ) : (
        <Col style={{ textAlign: 'center', marginTop: 15, marginBottom: 10 }}>
          <Avatar shape="square" style={{ height: 70, width: 80 }} src={AbpLogo} />
        </Col>
      )}

      <Menu theme="dark" mode="inline" selectedKeys={[currentRoute ? currentRoute.path : '']}>
        {appRouters
          .filter((item: any) => !item.isLayout && item.showInMenu)
          .map((route: any, index: number) => {
            if (route.permission && !isGranted(route.permission)) return null;

            return (
              <Menu.Item key={route.path} onClick={() => history.push(route.path)}>
                <route.icon />
                <span>{L(route.title)}</span>
              </Menu.Item>
            );
          })}
      </Menu>
    </Sider>
  );
};

export default SiderMenu;
