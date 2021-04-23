import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      console.log(res)
      AppState.vaults = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getVault(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      console.log(res)
      AppState.vault = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.vaults = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaults', vault)
    console.log(res)
    AppState.vaults = [res.data, ...AppState.vaults]
    // this.getVaultVaults(vault.vaultId)
  }

  async deleteVault(vaultId) {
    await api.delete('api/vaults/' + vaultId)
    const vaultIndex = AppState.vaults.findIndex(v => v.id === vaultId)
    AppState.vaults.splice(vaultIndex, 1)
  }
}
export const vaultsService = new VaultsService()
