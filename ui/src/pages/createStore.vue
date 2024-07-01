<script setup lang="ts">
import { onMounted, ref } from 'vue';
// const props = defineProps<{
//     product: string
// }>();
const userId = ref("");
onMounted(() => {
    userId.value = localStorage.getItem('user') || "";
});
</script>

<template>
    <h1>Creating store for user: {{ userId }}</h1>
</template>