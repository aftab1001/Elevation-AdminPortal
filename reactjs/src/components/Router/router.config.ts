import LoadableComponent from './../Loadable/index';
import { HomeOutlined, UserOutlined, WalletOutlined, AppstoreOutlined,TagsOutlined,LogoutOutlined } from '@ant-design/icons';

export const userRouter: any = [
  {
    path: '/user',
    name: 'user',
    title: 'User',
    component: LoadableComponent(() => import('../../components/Layout/UserLayout')),
    isLayout: true,
    showInMenu: false,
  },
  {
    path: '/user/login',
    name: 'login',
    title: 'LogIn',
    component: LoadableComponent(() => import('../../scenes/Login')),
    showInMenu: false,
  },
];

export const appRouters: any = [
  {
    path: '/',
    exact: true,
    name: 'home',
    permission: '',
    title: 'Home',
    component: LoadableComponent(() => import('../../components/Layout/AppLayout')),
    isLayout: true,
    showInMenu: false,
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    permission: '',
    title: 'Dashboard',
    icon: HomeOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Dashboard')),
  },
  {
    path: '/users',
    permission: 'Pages.Users',
    title: 'Users',
    name: 'user',
    icon: UserOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Users')),
  } ,
  {
    path: '/roles',
    permission: 'Pages.Roles',
    title: 'Roles',
    name: 'role',
    icon: TagsOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Roles')),
  },
  {
    path: '/rooms',
    permission: 'Pages.Rooms',
    title: 'Rooms',
    name: 'rooms',
    icon: WalletOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Rooms')),
  },
  {
    path: '/apartments',
    permission: 'Pages.Apartments',
    title: 'Apartments',
    name: 'apartments',
    icon: WalletOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Apartments')),
  },
  {
    path: '/tenants',
    permission: 'Pages.Tenants',
    title: 'Tenants',
    name: 'tenant',
    icon: AppstoreOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Tenants')),
  },
  {
    path: '/logout',
    permission: '',
    title: 'Logout',
    name: 'logout',
    icon: LogoutOutlined,
    showInMenu: true,
    component: LoadableComponent(() => import('../../components/Logout')),
  },
  {
    path: '/exception?:type',
    permission: '',
    title: 'exception',
    name: 'exception',
    showInMenu: false,
    component: LoadableComponent(() => import('../../scenes/Exception')),
  },
];

export const routers = [...userRouter, ...appRouters];
