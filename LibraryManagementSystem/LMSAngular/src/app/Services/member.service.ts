
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Member } from '../Models/member.model';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private apiUrl = 'https://localhost:7160/api/members';

  constructor(private http: HttpClient) {}

  getAllMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.apiUrl, this.getHeaders());
  }

  getMemberById(userId: string): Observable<Member> {
    return this.http.get<Member>(`${this.apiUrl}/${userId}`, this.getHeaders());
  }

  updateMember(member: Member): Observable<void> {
    const updatedMember = {
      userId: member.userId,
      name: member.name,
      email: member.email,
      membershipDate: new Date(member.membershipDate).toISOString(), 
      status: member.status || 'Active' 
    };
  
    return this.http.put<void>(`${this.apiUrl}/${member.userId}`, updatedMember, this.getHeaders());
  }
  

  deleteMember(userId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${userId}`, this.getHeaders());
  }

  // private getHeaders() {
  //   const token = localStorage.getItem('token');
  //   return {
  //     headers: new HttpHeaders({
  //       Authorization: `Bearer ${token}`,
  //       'Content-Type': 'application/json',
  //     }),
  //   };
  // }

  private getHeaders(): { headers: HttpHeaders } {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? `Bearer ${token}` : '',
      'Content-Type': 'application/json',
    });
    return { headers };
  }
  
}
