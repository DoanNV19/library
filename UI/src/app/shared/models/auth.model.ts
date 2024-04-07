export interface User {
  id?: number;
  userName?: string;
  fullName?: string;
  email: string;
  phone?: string;
  status?: number;
  gender?: number;
  isAdmin: boolean;
  department?: string;
  state?: boolean;
  lstRole?: number[];
  roleName?: string;
  isSystem?: boolean;
}
export interface UserAuth extends User {
  token?: string;
  refreshToken?: string;
  expireTime?: string;
  roles: string[];
}

export interface Role {
  id: number;
  code?: string;
  name?: string;
  status?: number;
  state?: boolean;
}
