export interface SceneSettings {
  width: number
  height: number
}
  
export interface SceneNode {
  id: string
  type: 'camera' | 'box'
  position: [number, number, number]
  rotation: [number, number, number]
  scale: [number, number, number]
}
  
export interface CameraSceneNode extends SceneNode {
  type: 'camera'
  properties: {
    fov: number
  }
}
  
export interface BoxSceneNode extends SceneNode {
  type: 'box'
  properties: {
    width: number
    height: number
    length: number
  }
}

export interface State { 
  sceneSettings: SceneSettings
  sceneNodes: (BoxSceneNode)[] 
};