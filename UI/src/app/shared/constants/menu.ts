import { MenuItem } from '../models/menu.model';

export const MENU: MenuItem[] = [
  {
    id: 1,
    label: 'Quản lý cho mượn',
    link: '/books',
    icon: 'ri-archive-drawer-fill'
  },
  {
    id: 2,
    label: 'Quản lý sách',
    link: '/books',
    icon: 'ri-book-open-fill'
  },
  {
    id: 3,
    label: 'Quản lý tác giả',
    link: '/books',
    icon: 'ri-briefcase-fill'
  },
  {
    id: 3,
    label: 'Quản lý khách hàng',
    link: '/books',
    icon: 'ri-file-user-fill'
  },
  {
    id: 3,
    label: 'Quản lý tài khoản',
    link: '/books',
    icon: 'ri-account-pin-box-fill'
  }
];
