export interface RouteModel {
  id: number;
  code: string;
  name: string;
  type: string;
  startPoint: string;
  endPoint: string;
  length: number;
  totalLane: number;
  status: number;
}

export interface DetailRouteModel {
  id: number;
  localId: string;
  code: string;
  name: string;
  startPoint: string;
  endPoint: string;
  type: number;
  typeName: string;
  status: number;
  length: number;
  laneCount: number;
  dependencyRoute?: DetailRouteModel[];
  state?: any;
}
