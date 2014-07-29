%Problem 6
%P2 - Prolog lists
%Date - 18/10/2013
%Chira Tudor - 922
%Define the predicates "isequal" and "lessthan" for numbers written in list representation domains

	el=integer
	list=el*
predicates
	isequal(list,list)
	less(list,list).
	length(list,integer)
clauses
	isequal([],[]).
	isequal([H|T],[H1|T1]):-H=H1,isequal(T,T1).
	
	length([],0).
	length([H|T],N):-length(T,N1),N=N1+1.
	
	less([],_).
	less(L,L1):-length(L,N),length(L1,N1),N<N1.
	less([H],[H1]):-H<H1.
	less([H|T],[H1|T1]):-H<=H1,less(T,T1).