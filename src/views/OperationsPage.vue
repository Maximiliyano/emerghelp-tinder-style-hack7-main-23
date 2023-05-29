<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class="px-4">
      <v-col class="pb-sm-3 pb-0 px-sm-2 px-2"><div class="text-h5">Ваші запити</div></v-col>
    </v-row>
    <HelpComponent/>
    <!-- <OperationsTable/> -->
  </v-container>
</template>

<script>
import HelpComponent from '@/components/HelpComponent'
// import OperationsTable from '@/components/OperationsTable'
export default {
  name: 'OperationsPage',
  components: { HelpComponent },
  data: () => ({

  }),
  methods: {

  }

}
</script>
