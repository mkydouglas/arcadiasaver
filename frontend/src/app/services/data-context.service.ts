import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class DataContextService {

    public url = 'http://localhost:5000';
	
	constructor(private http: HttpClient) { }
	
	public composeHeaders() {
		const token = localStorage.getItem('token');
		const headers = new HttpHeaders().set('Authorization', `bearer ${token}`);
		return headers;
    }
    
    authenticate(data) {
        var header = new HttpHeaders().set('Content-Type', 'application/json');
        return this.http.post(`${this.url}/Auth/Register`, data, {headers: header});
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
