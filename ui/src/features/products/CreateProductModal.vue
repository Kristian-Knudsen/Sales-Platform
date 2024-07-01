<script setup lang="ts">
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetDescription} from '@/components/ui/sheet';
import CreateProductForm from '@/components/CreateProductForm.vue';

const props = defineProps<{
    shouldOpen: boolean,
    closeFunction: (value: boolean) => any
}>();

</script>

<template>
    <Sheet :open="props.shouldOpen" :onUpdate:open="closeFunction">
        <SheetContent class="max-w-[500px] sm:max-w-[680px]">
            <SheetHeader>
                <SheetTitle>New product</SheetTitle>
            </SheetHeader>
            <SheetDescription>
                <CreateProductForm :closeFunction="closeFunction" />
            </SheetDescription>
        </SheetContent>
    </Sheet>
</template>