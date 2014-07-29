
%Problem 11 
%P1 - Prolog lists
%Date - 18/10/2013
%Chira Tudor - 922

%Problem statement - check if a list is a set

domains
	elem=integer
	list=el*
predicates
	member(el,list)
	isset(list)
clauses
	member(E,[E|_]).
	member(E,[_|T]):-member(E,T).
	
	isset([]).
	isset([H|T]):-not(member(H,T)),isset(T).