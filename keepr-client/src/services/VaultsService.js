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

  async getVaultsByAccountId() {
    const res = await api.get('account/vaults')
    console.log(res)
    AppState.vaults = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaults', vault)
    console.log(res)
    AppState.vaults = [res.data, ...AppState.vaults]
    // this.getVaultKeeps(vault.vaultId)
  }
}
export const vaultsService = new VaultsService()
