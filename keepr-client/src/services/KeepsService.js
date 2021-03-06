import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      console.log(res)
      AppState.keeps = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getKeep(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      console.log(res)
      AppState.activeKeep = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getKeepsByAccountId() {
    const res = await api.get('account/keeps')
    console.log(res)
    AppState.keeps = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    console.log(res)
    AppState.keeps = res.data
  }

  async createKeep(keep) {
    const res = await api.post('api/keeps', keep)
    console.log(res)
    AppState.keeps = [res.data, ...AppState.keeps]
    // this.getVaultKeeps(keep.vaultId)
  }

  async deleteKeep(keepId) {
    await api.delete('api/keeps/' + keepId)
    const keepIndex = AppState.keeps.findIndex(k => k.id === keepId)
    AppState.keeps.splice(keepIndex, 1)
  }

  async createVaultKeep(newVK) {
    const res = await api.post('api/vaultkeeps', newVK)
    console.log(res)
    AppState.vaultkeeps = [res.data, ...AppState.vaultkeeps]
  }

  async getVaultKeeps(id) {
    const res = await api.get('api/vaults/' + id + '/keeps')
    console.log(res)
    AppState.vaultkeeps = res.data
  }

  async deleteVaultKeep(vaultKeepId) {
    await api.delete('api/vaultkeeps/' + vaultKeepId)
    const vaultkeepIndex = AppState.keeps.findIndex(vk => vk.id === vaultKeepId)
    AppState.vaultkeeps.splice(vaultkeepIndex, 1)
  }
}
export const keepsService = new KeepsService()
