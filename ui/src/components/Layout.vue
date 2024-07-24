<script setup lang="ts">
import Sidebar from '@/features/Sidebar.vue';
import type { HTMLAttributes } from 'vue'
import { cn } from '@/lib/utils'

const props = defineProps<{
  class?: HTMLAttributes['class']
}>()
</script>

<template>
    <div class="grid min-h-screen w-full md:grid-cols-[220px_1fr] lg:grid-cols-[280px_1fr]">
        <Sidebar />
        <div class="flex flex-col">
            <main :class="cn('flex flex-1 flex-col gap-4 p-4 lg:gap-6 lg:p-6', props.class)">
                <slot />
            </main>
        </div>
    </div>
</template>