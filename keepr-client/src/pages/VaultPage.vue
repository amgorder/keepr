<template>
  <div class="Vault-Page text-light">
    <h1>{{ state.vault.name }}</h1>
    <p>
      number of Keeps {{ state.keeps.length }}
    </p>
    <h2>
      Delete VAULT?
      <i class="fa fa-trash text-danger pointer" @click="deleteVault" v-if="state.vault.creatorId == state.account.id" aria-hidden="true"></i>
    </h2>

    <h1> Keeps:</h1>
    <keep-component class="keep-component d-flex" v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import router from '../router'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vault: computed(() => AppState.vault),
      account: computed(() => AppState.account),

      keeps: computed(() => AppState.vaultkeeps)
    })
    onMounted(() => {
      keepsService.getVaultKeeps(route.params.id)
      vaultsService.getVault(route.params.id)
    })
    return {
      state,
      async deleteVault() {
        await confirm('Are you sure?')
        await vaultsService.deleteVault(state.vault.id)
        router.push({ name: 'Account' })
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

.pointer {
  cursor: crosshair;
  }
</style>
