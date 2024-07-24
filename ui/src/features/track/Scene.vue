<script setup lang="ts">
import { type Object3D } from 'three';
import { TresCanvas } from '@tresjs/core';
import { TransformControls } from '@tresjs/cientos';
import { ref, shallowRef, computed, watchEffect } from 'vue';
import { useElementSize } from '@vueuse/core';

import CustomTresOrbitControls from './CustomTresOrbitControls.vue';
import SceneNodeBox from './SceneNodeBox.vue';
import SceneNodeBoxProps from './SceneNodeBoxProps.vue';
import SceneSettingsProps from './SceneSettingsProps.vue';
import type { BoxSceneNode, State } from './types';

const state = ref<State>({ sceneSettings: { width: 800, height: 600 }, sceneNodes: []});
const selectedNodeId = ref<string | null>();
const transformControlFocused = ref(false);
const sceneNodeRefs = ref<{ [sceneNodeId: string]: Object3D }>({});
const tresCanvasRef = shallowRef();
const navCamRef = shallowRef();
const canvasContainerRef = shallowRef();


const selectedNode = computed(() => state.value.sceneNodes.find(i => i.id === selectedNodeId.value));
const orbitEnabled = computed(() => !transformControlFocused.value);

// when nav cam is active, update manually what is required
const canvasContainerSize = useElementSize(canvasContainerRef);
watchEffect(() => {
  if (navCamRef.value != null) {
    navCamRef.value.aspect = canvasContainerSize.width.value / canvasContainerSize.height.value
    navCamRef.value.updateProjectionMatrix()
  }
});

function addBoxSceneNode() {
  const newSceneNode: BoxSceneNode = {
    id: crypto.randomUUID(),
    type: 'box',
    properties: {
      width: 10,
      height: 10,
      length: 10,
    },
    position: [10, 5, 10],
    rotation: [0, 0, 0],
    scale: [1, 1, 1],
  }

  state.value.sceneNodes.push(newSceneNode);
  selectSceneNode(newSceneNode.id);
};

const selectSceneNode = (sceneNodeId: string) => selectedNodeId.value = sceneNodeId;

const getNearest10 = (n: number) => Math.floor(n / 10) * 5;

const getHalfOfHeight = (object: Object3D) => parseInt(object.toJSON().geometries[0].height) / 2;

const handleTransformChange = (sceneNodeId: string, object: Object3D) => {
  const sceneNode = state.value.sceneNodes.find(i => i.id === sceneNodeId)
  
  if (sceneNode != null) {
    sceneNode.position = [getNearest10(object.position.x), getHalfOfHeight(object), getNearest10(object.position.z)]
  }
}

const handleDeleteSceneNode = (sceneNodeId: string) => {
  if (selectedNodeId.value === sceneNodeId) {
    selectedNodeId.value = null
  }

  state.value.sceneNodes.splice(state.value.sceneNodes.findIndex(i => i.id === sceneNodeId), 1)
}

const exportWarehouseStructure = () => {
  console.log(state.value.sceneNodes);
};
</script>

<template>
  <div class="flex w-full inset-0 h-full">
    <div class="flex flex-col gap-2 bg-gray-800 p-2 min-w-[140px]">

      <div class="text-white">Scene Explorer</div>

      <div class="flex flex-col justify-center gap-2">
        <button class="bg-amber-500 py-2 rounded-xl text-white transition hover:bg-amber-600" @click="exportWarehouseStructure">Export warehouse</button>
        <button class="bg-blue-500 py-2 rounded-xl text-white transition hover:bg-blue-600" @click="addBoxSceneNode">Add rack</button>
      </div>
      
      <div class="flex flex-col flex-grow gap-2">
        <div
          v-for="sceneNode in state.sceneNodes"
          :key="sceneNode.id"
          class="flex justify-between text-white"
          :class="{ 'ring-2 ring-blue-400': sceneNode.id === selectedNodeId }"
        >
          <div @click="selectSceneNode(sceneNode.id)">{{ sceneNode.type }}</div>
          <p class="text-gray-400" @click="handleDeleteSceneNode(sceneNode.id)">Remove</p>
        </div>
      </div>

      <div>
        <b class="text-white">Scene Settings</b>
        <SceneSettingsProps v-model="state.sceneSettings" />
      </div>
      
      <div v-if="selectedNode != null" class="flex flex-col gap-2">
        <b class="text-white">Scene Node Properties</b>
        <SceneNodeBoxProps
          v-if="selectedNode.type === 'box'"
          :model-value="selectedNode"
          @update:model-value="selectedNode!.properties = $event.properties"
        />
      </div>
    </div>
    <div class="flex flex-col flex-grow">      
      <div class="flex flex-grow items-center justify-center border border-gray-700">
        <!-- <ContainElement
          :enabled="currentCameraName === 'render'"
          :aspect-ratio="state.sceneSettings.width / state.sceneSettings.height"
          class="border border-slate-400"
        > -->
          <div ref="canvasContainerRef" class="h-full w-full">
            <TresCanvas
              ref="tresCanvasRef"
              clear-color="slategrey"
            >
              <TresPerspectiveCamera
                ref="navCamRef"
                name="nav"
                :position="[50, 50, 50]"
                :far="3000"
              />

              <CustomTresOrbitControls
                v-if="navCamRef"
                :enabled="orbitEnabled"
                :camera="navCamRef"
              />

              <SceneNodeBox
                v-for="sceneNode in state.sceneNodes.filter((i) => i.type === 'box')"
                :key="sceneNode.id"    
                :ref="(el: any) => {sceneNodeRefs[sceneNode.id] = el?.mesh}"
                :position="sceneNode.position"
                :rotation="sceneNode.rotation"
                :scale="sceneNode.scale"
                :properties="(sceneNode as BoxSceneNode).properties"
                :first="state.sceneNodes.filter(i => i.type === 'box')[0] === sceneNode"
                @click="selectSceneNode(sceneNode.id)"
              />

              <TransformControls
                v-if="selectedNodeId != null"
                :object="sceneNodeRefs[selectedNodeId!]"
                mode="translate"
                space="world"
                @mouse-down="transformControlFocused = true"
                @mouse-up="transformControlFocused = false"
                @object-change="handleTransformChange(selectedNodeId!, sceneNodeRefs[selectedNodeId!])"
              />

              <!-- Floor -->
              <TresGridHelper :args="[100, 10, '#ffffff', '#ffffff']" />
            </TresCanvas>
          </div>
        <!-- </ContainElement> -->
      </div>
    </div>
  </div>
</template>