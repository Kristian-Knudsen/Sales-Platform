<script setup lang="ts">
import Toaster from '@/components/ui/toast/Toaster.vue'
</script>

<template>
  <!-- <div class="mx-auto max-w-[1366px] bg-neutral-200 h-full"> -->
  <div class="w-full bg-neutral-200 h-full">
    <router-view />
    <Toaster />
  </div>
</template>
