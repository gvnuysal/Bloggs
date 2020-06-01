import LoadableComponent from './../Loadable/index';
import { L } from '../../lib/abpUtility';

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
    icon: 'home',
    component: LoadableComponent(() => import('../../components/Layout/AppLayout')),
    isLayout: true,
    showInMenu: false,
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    permission: '',
    title: 'Dashboard',
    icon: 'home',
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Dashboard')),
  },
  {
    path: '/users',
    permission: 'Pages.Users',
    title: L('Users'),
    name: 'user',
    icon: 'user',
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Users')),
  },
  {
    path: '/roles',
    permission: 'Pages.Roles',
    title: L('Roles'),
    name: 'role',
    icon: 'tags',
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Roles')),
  },
  {
    path: '/tenants',
    permission: 'Pages.Tenants',
    title: L('Tenants'),
    name: 'tenant',
    icon: 'appstore',
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/Tenants')),
  },
  {
    path: '/about',
    permission: '',
    title: L('About'),
    name: 'about',
    icon: 'info-circle',
    showInMenu: true,
    component: LoadableComponent(() => import('../../scenes/About')),
  },
  {
    path: '/logout',
    permission: '',
    title: L('Logout'),
    name: 'logout',
    icon: 'info-circle',
    showInMenu: false,
    component: LoadableComponent(() => import('../../components/Logout')),
  },
  {
    path: '/exception?:type',
    permission: '',
    title: 'exception',
    name: 'exception',
    icon: 'info-circle',
    showInMenu: false,
    component: LoadableComponent(() => import('../../scenes/Exception')),
  },
  {
    path:'/categories',
    permission:'',
    title:L('Categories'),
    name:'categories',
    icon: 'bars',
    showInMenu: true,
    component:LoadableComponent(()=>import('../../scenes/Category')),

  },
  {
    path:'/tags',
    permission:'',
    title:L('Tags'),
    name:'tags',
    icon: 'tag',
    showInMenu: true,
    component:LoadableComponent(()=>import('../../scenes/Tag')),

  }
];

export const routers = [...userRouter, ...appRouters];
