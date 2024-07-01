<script setup lang="ts"> 
import { FunctionalComponent } from 'vue';
import { useRoute } from 'vue-router';
import { Badge } from '@/components/ui/badge';
const route = useRoute();

const props = defineProps<{
    link: string,
    icon: FunctionalComponent,
    text: string,
    badge?: string,
}>();
</script>

<template>
    <a :href="props.link" :class="[ route.path === props.link ? 'bg-muted' : null]" class="flex items-center gap-3 rounded-lg px-3 py-2 text-muted-foreground transition-all hover:text-primary">
        <component :is="props.icon" class="h-4 w-4" />
        {{ props.text }}
        <Badge v-if="props.badge" class="ml-auto flex h-6 w-6 shrink-0 items-center justify-center rounded-full">
            {{ props.badge }}
        </Badge>
    </a>
</template>