export interface User {
  id?: number;
  userName?: string;
  fullName?: string;
  EmailId?: string;
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
export interface UserAuth {
  accessToken?: string;
  refreshToken?: string;
  expireTime?: string;
  user: User;
}

export interface Role {
  id: number;
  code?: string;
  name?: string;
  status?: number;
  state?: boolean;
}
