<template>
  <div class="about container-fluid">
    <div class="row justify-content-center">
      <div class="col-6">
        <h1>Welcome {{ state.account.name }} !</h1>
        <img class="rounded" :src="state.account.picture" alt="" />
        <p>{{ state.account.email }}</p>
      </div>
    </div>
    <div class="row">
      <!-- Button trigger modal -->
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
        + KEEP
      </button>

      <!-- Modal -->
      <div class="modal fade"
           id="exampleModalCenter"
           tabindex="-1"
           role="dialog"
           aria-labelledby="exampleModalCenterTitle"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLongTitle">
                New Keep:
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              ...
              <form @submit.prevent="createKeep">
                <input class="m-3" type="text" v-model="state.newKeep.name" placeholder="Enter a name">
                <input class="m-3" type="text" v-model="state.newKeep.img" placeholder="Enter a img">
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="submit" class="btn btn-primary">
                Create Keep
              </button>
            </div>
          </div>
        </div>
      </div>

      <div class="col p-3">
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
