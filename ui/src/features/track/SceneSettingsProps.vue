<script setup lang="ts">
import type { SceneSettings } from './types'
import { PropType, toRefs, ref, toRaw, watch } from 'vue';

const props = defineProps({
  modelValue: {
    type: Object as PropType<SceneSettings>,
    required: true,
  },
})

const emit = defineEmits(['update:modelValue'])

const { modelValue } = toRefs(props)
const internalModelValue = ref<SceneSettings>(structuredClone(toRaw(modelValue.value)))
watch(modelValue, () => {
  internalModelValue.value = structuredClone(toRaw(modelValue.value))
})
function handleModelValueUpdate() {
  emit('update:modelValue', structuredClone(toRaw(internalModelValue.value)))
}
</script>

<template>
  <div class="grid grid-cols-[auto_auto] gap-1">
    <p class="text-white">Width:</p> 
    <input v-model="internalModelValue.width" class="text-black" @update:model-value="handleModelValueUpdate" />
    
    <p class="text-white">Height:</p>
    <input v-model="internalModelValue.height" class="text-black" @update:model-value="handleModelValueUpdate" />
  </div>
</template>