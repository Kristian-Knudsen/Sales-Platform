<script setup lang="ts">
import { extend, useTresContext } from '@tresjs/core'
import { OrbitControls } from 'three-stdlib';
import { ref } from 'vue';

const props = defineProps({
  enabled: {
    type: Boolean,
    default: true,
  },
  camera: {
    type: Object,
  },
})

const { renderer } = useTresContext();

const orbitControlsRef = ref()

extend({ OrbitControls });

defineExpose({ value: orbitControlsRef })
</script>

<template>
  <TresOrbitControls
    v-if="renderer"
    :key="props.camera?.uuid"
    ref="orbitControlsRef"
    :args="[props.camera, renderer?.domElement]"
    :camera="props.camera"
    :enabled="enabled"
    makeDefault
  />
</template>
