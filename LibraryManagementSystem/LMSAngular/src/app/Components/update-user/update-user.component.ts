import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { MemberService } from '../../Services/member.service';
import { Member } from '../../Models/member.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-user',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {
  member: Member = { 
    userId: '', 
    name: '', 
    email: '', 
    membershipDate: new Date().toISOString(), 
    status: 'Active'
  };
  
  userId: string = '';

  constructor(
    private memberService: MemberService,
    private route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('id') || '';
    if (this.userId) {
      this.memberService.getMemberById(this.userId).subscribe({
        next: (data) => {
          this.member = data;
        },
        error: (err) => console.error('Error fetching user:', err),
      });
    }
  }

  updateUser() {
    this.memberService.updateMember(this.member).subscribe({
      next: () => {
        alert('User updated successfully!');
        this.router.navigate(['/admin-dashboard']); 
      },
      error: (err) => console.error('Error updating user:', err),
    });
  }
}
