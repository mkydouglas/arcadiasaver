import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Retorno } from '../model/Retorno';
import { RetornoCampanha } from '../model/RetornoCampanha';
import { AddTeamDto } from '../model/AddTeamDto';
import { RetornoTeam } from '../model/RetornoTeam';
import { AddHeroDto } from '../model/AddHeroDto';
import { RetornoHero } from '../model/RetornoHero';
import { RetornaUmTime } from '../model/RetornaUmTime';

@Injectable({
	providedIn: 'root'
})
export class DataContextService {

    public url = 'http://localhost:5000';
	
	constructor(private http: HttpClient) { }
	
	public composeHeaders() {
        const token = sessionStorage.getItem('token');
        var a:Retorno = JSON.parse(token);
		const headers = new HttpHeaders().set('Authorization', `bearer ${a.data}`);
		return headers;
    }
    
    registrar(data) {
        var header = new HttpHeaders().set('Content-Type', 'application/json');
        return this.http.post<Retorno>(`${this.url}/Auth/Register`, data);
    }
    
    logar(data) {
        var header = new HttpHeaders().set('Content-Type', 'application/json');
        return this.http.post<Retorno>(`${this.url}/Auth/Login`, data);
    }

    addCampanha(data, playerId: number) {
        return this.http.post<RetornoCampanha>(`${this.url}/Campaign?playerId=${playerId}`, data);
    }

    buscarCampanha(campanhaId: string){
        return this.http.get<RetornoCampanha>(`${this.url}/Campaign?campaignId=${campanhaId}`);
    }

    entrarNaCampanha(data) {
        return this.http.post(`${this.url}/PlayerCampaign`, data);
    }

    addTeam(team: AddTeamDto){
        return this.http.post<RetornoTeam>(`${this.url}/team`, team, { headers: this.composeHeaders() });
    }

    addHero(hero: AddHeroDto, teamId: number){
        return this.http.post<RetornoHero>(`${this.url}/hero/${teamId}`, hero, { headers: this.composeHeaders() });
    }

    getTeam(id: number){
        return this.http.get<RetornaUmTime>(`${this.url}/team/${id}`, { headers: this.composeHeaders() });
    }


    /**
     * 
     * 
     * getProducts() {
        return this.http.get<Product[]>(`${this.url}/products`);
    }

    authenticate(data) {
        return this.http.post(`${this.url}/accounts/authenticate`, data);
    }

    refreshToken() {
        return this.http.post(
            `${this.url}/accounts/refresh-token`,
            null,
            { headers: this.composeHeaders() }
        );
    }

    create(data) {
        return this.http.post(`${this.url}/accounts`, data);
    }

    resetPassword(data) {
        return this.http.post(`${this.url}/accounts/reset-password`, data);
    }

    getProfile() {
        return this.http.get(`${this.url}/accounts`, { headers: this.composeHeaders() });
    }

    updateProfile(data) {
        return this.http.put(`${this.url}/accounts`, data, { headers: this.composeHeaders() });
    }
     * 
     */
}
