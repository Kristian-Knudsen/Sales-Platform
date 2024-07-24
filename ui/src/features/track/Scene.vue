<script setup lang="ts">
import { TresCanvas } from '@tresjs/core';
</script>

<template>
    <TresCanvas window-size>
            <TresPerspectiveCamera :args="[45, 1, 0.1, 1000]" />

            <TresScene>
                <TresMesh>
                    <TresTorusGeometry :args="[1, 0.5, 16, 32]" />
                    <TresMeshBasicMaterial color="orange" />
                </TresMesh>
            </TresScene>
    </TresCanvas>
</template>