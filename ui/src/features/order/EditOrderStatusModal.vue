<script setup lang="ts">
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetDescription} from '@/components/ui/sheet';
import { ref } from 'vue'
import { CaretSortIcon, CheckIcon } from '@radix-icons/vue';
import { OrderStatusText, OrderStatus } from '@/types';

import { cn } from '@/lib/utils'
import { Button } from '@/components/ui/button'
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
} from '@/components/ui/command'
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover'

const open = ref(false)
const value = ref('')

const props = defineProps<{
    shouldOpen: boolean,
    closeFunction: (value: boolean) => any,
    orderId: string,
    currentStatus: string
}>();

</script>

<template>
    <Sheet :open="props.shouldOpen" :onUpdate:open="closeFunction">
        <SheetContent class="max-w-[500px] sm:max-w-[680px]">
            <SheetHeader>
                <SheetTitle>Update status for order: {{ props.orderId }}</SheetTitle>
            </SheetHeader>
            <SheetDescription>
                <p>Current status: {{ props.currentStatus }}</p>

                <Popover v-model:open="open">
                    <PopoverTrigger as-child>
                    <Button
                        variant="outline"
                        role="combobox"
                        :aria-expanded="open"
                        class="w-[200px] justify-between"
                    >
                        {{ value
                        // Find some way to make this show the text if there is selected a value
                        ? value
                        : "Select new status..." }}
                        <CaretSortIcon class="ml-2 h-4 w-4 shrink-0 opacity-50" />
                    </Button>
                    </PopoverTrigger>
                    <PopoverContent class="w-[200px] p-0">
                    <Command>
                        <CommandInput class="h-9" placeholder="Search framework..." />
                        <CommandEmpty>No framework found.</CommandEmpty>
                        <CommandList>
                        <CommandGroup>
                            <CommandItem
                            v-for="status in OrderStatusText"
                            :key="status"
                            :value="status"
                            @select="(ev) => {
                                if (typeof ev.detail.value === 'string') {
                                value = ev.detail.value
                                }
                                open = false
                            }"
                            >
                            {{ status }}
                            <CheckIcon
                                :class="cn(
                                'ml-auto h-4 w-4',
                                value === status ? 'opacity-100' : 'opacity-0',
                                )"
                            />
                            </CommandItem>
                        </CommandGroup>
                        </CommandList>
                    </Command>
                    </PopoverContent>
                </Popover>
            </SheetDescription>
        </SheetContent>
    </Sheet>
</template>