<template>
  <div class="Vault-Page text-light">
    <h1>Vault Title</h1>
    <p>
      number of Keeps

      delete vault button that removes all keeps

      Keep-component
    </p>
    <keep-component class="keep-component d-flex" v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.vaultkeeps)
    })
    onMounted(() => {
      keepsService.getVaultKeeps(route.params.id)
    })
    return {
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
