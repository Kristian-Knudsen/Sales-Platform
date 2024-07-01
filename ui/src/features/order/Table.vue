<script setup lang="ts">
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { Badge } from '@/components/ui/badge';
import { Card, CardHeader, CardTitle, CardDescription, CardContent } from '@/components/ui/card';
</script>

<template>
  <Card class="h-full flex-grow">
    <CardHeader class="px-7">
      <CardTitle>Orders</CardTitle>
      <CardDescription>
        Recent orders from your store.
      </CardDescription>
    </CardHeader>

    <CardContent>
      <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Customer</TableHead>
          <TableHead class="hidden sm:table-cell">
            Type
          </TableHead>
          <TableHead class="hidden sm:table-cell">
            Status
          </TableHead>
          <TableHead class="hidden md:table-cell">
            Date
          </TableHead>
          <TableHead class="text-right">
            Amount
          </TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow class="bg-accent">
          <TableCell>
            <div class="font-medium">
              Liam Johnson
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              liam@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Sale
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-23
          </TableCell>
          <TableCell class="text-right">
            $250.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Olivia Smith
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              olivia@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Refund
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="outline">
              Declined
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-24
          </TableCell>
          <TableCell class="text-right">
            $150.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Noah Williams
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              noah@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Subscription
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-25
          </TableCell>
          <TableCell class="text-right">
            $350.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Emma Brown
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              emma@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Sale
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-26
          </TableCell>
          <TableCell class="text-right">
            $450.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Liam Johnson
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              liam@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Sale
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-23
          </TableCell>
          <TableCell class="text-right">
            $250.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Liam Johnson
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              liam@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Sale
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-23
          </TableCell>
          <TableCell class="text-right">
            $250.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Olivia Smith
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              olivia@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Refund
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="outline">
              Declined
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-24
          </TableCell>
          <TableCell class="text-right">
            $150.00
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <div class="font-medium">
              Emma Brown
            </div>
            <div class="hidden text-sm text-muted-foreground md:inline">
              emma@example.com
            </div>
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            Sale
          </TableCell>
          <TableCell class="hidden sm:table-cell">
            <Badge class="text-xs" variant="secondary">
              Fulfilled
            </Badge>
          </TableCell>
          <TableCell class="hidden md:table-cell">
            2023-06-26
          </TableCell>
          <TableCell class="text-right">
            $450.00
          </TableCell>
        </TableRow>
      </TableBody>
    </Table>
    </CardContent>
  </Card>
</template>