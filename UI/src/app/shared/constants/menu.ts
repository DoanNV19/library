import { MenuItem } from '../models/menu.model';

export const MENU: MenuItem[] = [
  {
    id: 1,
    label: 'Quản lý phương tiện, chủ phương tiện',
    link: '/vehicle-management',
    icon: 'ri-roadster-fill',
    subItems: [
      {
        label: 'Quản lý phương tiện',
        link: '/vehicle-management',
        icon: 'ri-roadster-fill'
      },
      {
        label: 'Quản lý chủ phương tiện',
        link: '/vehicle-owner-management',
        icon: 'ri-file-user-fill'
      },
      {
        label: 'Danh sách xe hạn chế, ưu tiên',
        link: '/black-white',
        icon: 'ri-file-paper-2-fill'
      }
    ]
  },
  {
    id: 4,
    label: 'Quản lý BOO, BOT',
    icon: 'ri-stack-fill',
    subItems: [
      {
        label: 'Quản lý đơn vị BOO đường bộ',
        icon: 'ri-stack-fill',
        link: '/boo'
      },
      {
        label: 'Quản lý dự án BOT',
        icon: 'ri-stack-fill',
        link: '/bot'
      },
      {
        label: 'Quản lý trạm',
        link: '/station',
        icon: 'ri-home-3-fill'
      },
      {
        label: 'Quản lý tuyến đường ',
        icon: 'ri-bar-chart-2-fill',
        link: '/route-list'
      }
    ]
  },

  {
    id: 8,
    label: 'Quản lý trung gian thanh toán',
    link: '/payment-intermediary',
    icon: ' ri-coins-fill'
  },
  {
    id: 9,
    label: 'Quản lý điểm chấp nhận thanh toán',
    icon: ' ri-map-pin-5-fill',
    link: '/payment-point'
  },
  {
    id: 11,
    label: 'Tra cứu lịch sử giao dịch',
    icon: 'ri-file-search-fill',
    link: '/transaction'
  },
  {
    id: 12,
    label: 'Quản lý cấu hình thu phí',
    link: '/fee-management',
    icon: 'ri-file-settings-fill'
  },
  {
    id: 13,
    label: 'Quản trị hệ thống',
    icon: 'ri-settings-4-fill',
    role: 'ROLE_ADMIN',
    subItems: [
      {
        id: 10,
        label: 'Quản lý ngành dịch vụ',
        icon: 'ri-account-box-fill',
        link: '/service-industry',
        role: 'ROLE_ADMIN'
      },

      {
        id: 13,
        label: 'Quản lý danh mục',
        link: '/category',
        icon: 'ri-file-list-fill',
        role: 'ROLE_ADMIN'
      },
      {
        id: 14,
        label: 'Tài khoản',
        icon: 'ri-account-box-fill',
        link: '/user',
        role: 'ROLE_ADMIN'
      },
      {
        id: 15,
        label: 'Quản lý vai trò',
        icon: 'ri-account-box-fill',
        link: '/role',
        role: 'ROLE_ADMIN'
      },
      {
        id: 15,
        label: 'Danh mục tỉnh, huyện, xã',
        icon: 'ri-user-location-fill',
        link: '/location',
        role: 'ROLE_ADMIN'
      }
    ]
  }
];
