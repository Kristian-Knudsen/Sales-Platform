<script setup lang="ts">
import { TresCanvas } from '@tresjs/core';
import Rack from './Rack.vue';
import Floor from './Floor.vue';
import { OrbitControls } from '@tresjs/cientos';
import { TransformControls } from 'three/addons/controls/TransformControls.js';
import { ref } from 'vue';

const activeControl = ref();
</script>

<template>
    <TresCanvas window-size>
        <TresPerspectiveCamera :args="[45, 1, 0.1, 1000]" />
        <OrbitControls makeDefault />
        <TransformControls :object="activeControl" />

        <TresScene>
            <Floor />
            <Rack />
        </TresScene>
    </TresCanvas>
</template>