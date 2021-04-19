<template>
  <div class="about container-fluid">
    <div class="row justify-content-center">
      <div class="col-6">
        <h1>Welcome {{ state.account.name }} </h1>
        <p>*login info should be displaying here</p>
        <!-- not getting account info -->
        <img class="rounded" :src="state.account.picture" alt="" />
        <p>{{ state.account.email }}</p>
      </div>
    </div>
    <div class="row">
      <div class="col p-3">
        <div class="card">
          <h3>Create a NEW Keep!</h3>
          <p>*create card with all Keep fields needed to create new KEEP</p>
          <form @submit.prevent="createKeep">
            <input class="m-3" type="text" v-model="state.newKeep.name" placeholder="Enter a name">
            <input class="m-3" type="text" v-model="state.newKeep.img" placeholder="Enter a img">

            <button type="submit" class="btn btn-primary">
              Create Keep
            </button>
          </form>
        </div>
      </div>
    </div>
    <br>
    <div class="row">
      <vault-component v-for="v in state.vault" :key="v.id" :vault-prop="v" />
      *Vaults will go here
    </div>
    <br>
    <div class="row">
      <keep-component v-for="k in state.keep" :key="k.id" :vault-prop="k" />
      *Keeps will go here
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Account',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      newKeep: {}

    })
    onMounted(() => vaultsService.getVaultsByAccountId())
    return {
      state,
      createKeep() {
        keepsService.createKeep(state.newKeep)
        state.newKeep = {}
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
