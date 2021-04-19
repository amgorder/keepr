<template>
  <div class="keepComponent col-3">
    <h3>{{ keepProp }}</h3>
    HeLLo WorLd
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style scoped>
</style>
